namespace Matrix
{
    using System;

    /// <summary>
    /// The argument of the event that occurs when the matrix values are updated.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the value.
    /// </typeparam>
    public class ElementChangesEventArgs<T> : EventArgs
    {
        /// <summary>
        /// Old value.
        /// </summary>
        public readonly T OldValue;

        /// <summary>
        /// New value.
        /// </summary>
        public readonly T NewValue;

        /// <summary>
        /// Row Number in Matrix.
        /// </summary>
        public readonly int Row;

        /// <summary>
        /// Column Number in Matrix.
        /// </summary>
        public readonly int Column;

        /// <summary>
        /// Constructor for creating instances.
        /// </summary>
        /// <param name="oldValue">Old value.</param>
        /// <param name="newValue"> New value.</param>
        /// <param name="row">Row Number in Matrix.</param>
        /// <param name="column">Column Number in Matrix.</param>
        public ElementChangesEventArgs(T oldValue, T newValue, int row, int column)
        {
            this.OldValue = oldValue;
            this.NewValue = newValue;
            this.Row = row;
            this.Column = column;
        }
    }
}
