using DoItFast.Application.Exceptions;
using DoItFast.Domain.Core.Abstractions.Wrappers;

namespace DoItFast.Application.Wrappers
{
    /// <summary>
    /// Blueberry response
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ValidationResponse : IValidationResponse
    {
        /// <summary>
        /// Unsuccessful response
        /// </summary>
        /// <param name="message"></param>
        public ValidationResponse(string message, ValidationException exception)
        {
            Succeeded = false;
            Message = message;
            Errors = exception.Errors;
        }

        /// <inheritdoc />
        public bool Succeeded { get; set; }

        /// <inheritdoc />
        public string Message { get; set; }

        /// <inheritdoc />
        public Dictionary<string, string> Errors { get; set; }
    }
}
