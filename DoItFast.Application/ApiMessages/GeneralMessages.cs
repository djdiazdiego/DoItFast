using System.ComponentModel;

namespace DoItFast.Application.ApiMessages
{
    public enum GeneralMessages
    {
        /// <summary>
        /// The field cannot be null.
        /// </summary>
        [Description("The field cannot be null.")]
        NotEmpty = 1,
        /// <summary>
        /// The value is invalid.
        /// </summary>
        [Description("The value is invalid.")]
        InvalidValue = 2,
        /// <summary>
        /// Must be greater.
        /// </summary>
        [Description("Must be greater than")]
        GreaterThan = 3,
        /// <summary>
        /// Must be less.
        /// </summary>
        [Description("Must be less than")]
        LessThan = 4,
        /// <summary>
        /// Length must be equal.
        /// </summary>
        [Description("Length must be equal to")]
        LengthEqual = 5,
        /// <summary>
        /// Not found.
        /// </summary>
        [Description("Not found.")]
        NotFound = 6
    }
}
