namespace AnimationTest
{
    using System.Runtime.InteropServices;

    class KTimer
    {
        // Natywne metody
        [DllImport("Kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool QueryPerformanceCounter(out long perfCount);
        [DllImport("Kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool QueryPerformanceFrequency(out long freq);

        private static long frequency = 0;
        private static long lastElapsedTime = 0;

        public static void SetupTimer()
        {
            QueryPerformanceFrequency(out frequency);
            QueryPerformanceCounter(out lastElapsedTime);
        }
        public static float GetElapsedTime()
        {
            long actualTime;
            float elapsedTime;
            QueryPerformanceCounter(out actualTime);
            elapsedTime = (actualTime - lastElapsedTime) * 1.0f / frequency;
            lastElapsedTime = actualTime;
            return elapsedTime;
        }
    }
}
