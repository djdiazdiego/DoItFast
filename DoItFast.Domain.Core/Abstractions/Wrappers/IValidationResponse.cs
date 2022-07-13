using System.Collections.Generic;

namespace DoItFast.Domain.Core.Abstractions.Wrappers
{
    public interface IValidationResponse : IBaseResponse
    {
        /// <summary>
        /// Response status.
        /// </summary>
        bool Succeeded { get; }

        /// <summary>
        /// Custom message.
        /// </summary>
        string Message { get; }

        /// <summary>
        /// Error dictionary.
        /// </summary>
        Dictionary<string, string> Errors { get; }
    }
}
