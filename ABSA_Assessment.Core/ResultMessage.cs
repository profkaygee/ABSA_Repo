using System.Runtime.Serialization;

namespace ABSA_Assessment.Core
{
    /// <summary>
    /// The result message type
    /// </summary>
    [DataContract]
    public class ResultMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResultMessage"/> class.
        /// </summary>
        /// <param name="messageType">Type of the message.</param>
        /// <param name="code">The code.</param>
        /// <param name="message">The message.</param>
        public ResultMessage(ResultMessageType messageType, string code, string message)
        {
            this.MessageType = messageType;
            this.Code = code;
            this.Message = message;
        }

        /// <summary>
        /// Gets the type of the message.
        /// </summary>
        /// <value>
        /// The type of the message.
        /// </value>
        [DataMember(Name = "messageType")] public ResultMessageType MessageType { get; }

        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        [DataMember(Name = "message")] public string Message { get; }

        /// <summary>
        /// Gets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        [DataMember(Name = "code")] public string Code { get; }
    }
}