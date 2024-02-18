using System;

namespace SYLO.Test
{
    public class TestComponent
    {
        static void Main()
        {

        }

        public static void MoveElement<T>(T[] array, int source, int dest)
        {
            if (array == null)
            {
                WriteError(typeof(ArgumentNullException));
                return;
            }      
            if (source < 0 || source > 6 || dest < 0 || dest > 6)
            {
                WriteError(typeof(ArgumentOutOfRangeException));
                return;
            }
            T cell = array[source];
            if (source < dest)
            {
                for (int i = source; i < dest; i++)
                    array[i] = array[i + 1];
                array[dest] = cell;
            }
            else if(source > dest)
            {
                for (int i = source; i > dest; i--)
                    array[i] = array[i - 1];
                array[dest] = cell;
            }
        }

        static TestComponent()
        {
            var testInputs = new TestData[]
            {
                new TestData{ array = null, source = 0, dest = 0, exceptionType = typeof(ArgumentNullException) },
                new TestData{ array = new int[] { 0, 1, 2, 3, 4, 5, 6 }, source = -1, dest = 1, exceptionType = typeof(ArgumentOutOfRangeException) },
                new TestData{ array = new int[] { 0, 1, 2, 3, 4, 5, 6 }, source = 0, dest = -1, exceptionType = typeof(ArgumentOutOfRangeException) },
                new TestData{ array = new int[] { 0, 1, 2, 3, 4, 5, 6 }, source = 0, dest = 7, exceptionType = typeof(ArgumentOutOfRangeException) },
                new TestData{ array = new int[] { 0, 1, 2, 3, 4, 5, 6 }, source = 7, dest = 0, exceptionType = typeof(ArgumentOutOfRangeException) },
                new TestData{ array = new int[] { 0, 1, 2, 3, 4, 5, 6 }, source = 0, dest = 0, correctArray = new int[] { 0, 1, 2, 3, 4, 5, 6 }},
                new TestData{ array = new int[] { 0, 1, 2, 3, 4, 5, 6 }, source = 4, dest = 4, correctArray = new int[] { 0, 1, 2, 3, 4, 5, 6 }},
                new TestData{ array = new int[] { 0, 1, 2, 3, 4, 5, 6 }, source = 0, dest = 1, correctArray = new int[] { 1, 0, 2, 3, 4, 5, 6 }},
                new TestData{ array = new int[] { 0, 1, 2, 3, 4, 5, 6 }, source = 1, dest = 0, correctArray = new int[] { 1, 0, 2, 3, 4, 5, 6 }},
                new TestData{ array = new int[] { 0, 1, 2, 3, 4, 5, 6 }, source = 0, dest = 2, correctArray = new int[] { 1, 2, 0, 3, 4, 5, 6 }},
                new TestData{ array = new int[] { 0, 1, 2, 3, 4, 5, 6 }, source = 2, dest = 0, correctArray = new int[] { 2, 0, 1, 3, 4, 5, 6 }},
                new TestData{ array = new int[] { 0, 1, 2, 3, 4, 5, 6 }, source = 1, dest = 2, correctArray = new int[] { 0, 2, 1, 3, 4, 5, 6 }},
                new TestData{ array = new int[] { 0, 1, 2, 3, 4, 5, 6 }, source = 2, dest = 1, correctArray = new int[] { 0, 2, 1, 3, 4, 5, 6 }},
                new TestData{ array = new int[] { 0, 1, 2, 3, 4, 5, 6 }, source = 2, dest = 5, correctArray = new int[] { 0, 1, 3, 4, 5, 2, 6 }},
                new TestData{ array = new int[] { 0, 1, 2, 3, 4, 5, 6 }, source = 5, dest = 2, correctArray = new int[] { 0, 1, 5, 2, 3, 4, 6 }},
                new TestData{ array = new int[] { 0, 1, 2, 3, 4, 5, 6 }, source = 0, dest = 6, correctArray = new int[] { 1, 2, 3, 4, 5, 6, 0 }},
                new TestData{ array = new int[] { 0, 1, 2, 3, 4, 5, 6 }, source = 6, dest = 0, correctArray = new int[] { 6, 0, 1, 2, 3, 4, 5 }},
            };

            var success = 0;
            var count = testInputs?.Length ?? 0;
            for (int n = 0; n < count; ++n)
            {
                if (TestComponent.Test(n + 1, count, testInputs[n]))
                    ++success;
            }

            Console.WriteLine($"TEST_RESULT_TOTAL: {success}/{count} ({(0 < count ? success / (float)count : 0):P2})");
        }

        static bool Test(int no, int total, TestData input)
        {
            var array = null != input.array ? (int[])input.array.Clone() : null;
            var success = false;
            try
            {
                TestComponent.MoveElement(array, input.source, input.dest);
                success = Verify(array, input.correctArray) && null == input.exceptionType;
                Action<object> log;
                if (success == true)
                    log = Console.WriteLine;
                else
                    log = TestComponent.WriteError;
                log($"TEST_RESULT[{no}/{total}]: {TestComponent.ToArrayJson(array)}, INPUT: {input}");
            }
            catch (Exception e)
            {
                success = Verify(null, input.correctArray) && e.GetType() == input.exceptionType;
                Action<object> log;
                if (success == true)
                    log = Console.WriteLine;
                else
                    log = TestComponent.WriteError;
                log($"TEST_EXCEPT[{no}/{total}]: {e.GetType().Name}, MESSAGE: {e.Message}, INPUT: {input}");
            }
            return success;

            static bool Verify(int[] a, int[] b)
            {
                var lenA = a?.Length ?? 0;
                var lenB = b?.Length ?? 0;
                if (lenA != lenB)
                    return false;

                for (int n = 0; n < lenA; ++n)
                {
                    if (a[n] != b[n])
                        return false;
                }
                return true;
            }
        }

        struct TestData
        {
            internal int[] array;
            internal int source;
            internal int dest;

            internal int[] correctArray;
            internal Type exceptionType;

            public override string ToString()
            {
                var array = TestComponent.ToArrayJson(this.array);
                var correctArray = TestComponent.ToArrayJson(this.correctArray);
                var exceptionType = null != this.exceptionType ? $"\"{this.exceptionType}\"" : "null";
                return $"{{\"array\": {array}, \"source\": {this.source}, \"dest\": {this.dest}, \"correctArray\": {correctArray}, \"exceptionType\": {exceptionType}}}";
            }
        }

        static string ToArrayJson<T>(System.Collections.Generic.IEnumerable<T> enumerable, Func<T, string> toString = null)
        {
            if (null == enumerable)
                return "null";

            var sb = new System.Text.StringBuilder();
            sb.Append('[');
            var first = true;
            foreach (var element in enumerable)
            {
                if (!first)
                    sb.Append(", ");
                first = false;

                if (null != toString)
                    sb.Append(toString(element));
                else
                    sb.Append(element.ToString());
            }
            sb.Append(']');
            return sb.ToString();
        }

        static void WriteError(object obj)
        {
            Console.WriteLine($"### ERROR ### {obj}");
        }
    }
}
