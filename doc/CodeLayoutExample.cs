namespace App
{
    using System;

    using External;

    using Internal;

    using Symbol = Namespace.Symbol;

    /// <summary>
    /// Xml Comment that describes why not necessarily what.
    /// </summary>
    public class Foo
    {
        public Action OnEvent;

        public static int Static;
        public const int Const;
        public int Prop { get; set };
        public int Field;

        internal static int Static;
        internal const int Const;
        internal int Prop { get; set };
        internal int Field;

        protected static int _Static;
        protected const int _Const;
        protected int _Prop { get; set };
        protected int _Field;

        private static int _static;
        private const int _const;
        private int _prop { get; set };
        private int _field;

        public static void Bar()
        {
        }

        internal static void Bar()
        {
        }

        protected static void Bar()
        {
        }

        private static void Bar()
        {
        }

        public void Bar()
        {
        }
        
        internal void Bar()
        {
        }

        protected void Bar()
        {
        }

        private void Bar()
        {
        }
    }
}
