using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ABSA_Assessment.Core
{
    /// <summary>
    /// The command result
    /// </summary>
    [DataContract]
    public class CommandResult
    {
        private readonly IList<ResultMessage> _messages;

        /// <summary>
        /// Gets a value indicating whether this <see cref="CommandResult"/> is accepted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if accepted; otherwise, <c>false</c>.
        /// </value>
        [DataMember(Name = "accepted")]
        public bool Accepted { get; }

        /// <summary>
        /// Gets the resource URL.
        /// </summary>
        /// <value>
        /// The resource URL.
        /// </value>
        [DataMember(Name = "resourceUrl")]
        public string ResourceUrl { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandResult"/> class.
        /// </summary>
        /// <param name="accepted">if set to <c>true</c> [accepted].</param>
        public CommandResult(bool accepted)
        {
            Accepted = accepted;
            _messages = new List<ResultMessage>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandResult"/> class.
        /// </summary>
        /// <param name="accepted">if set to <c>true</c> [accepted].</param>
        /// <param name="url">The URL.</param>
        public CommandResult(bool accepted, string url)
        {
            Accepted = accepted;
            ResourceUrl = url;
            _messages = new List<ResultMessage>();
        }

        /// <summary>
        /// Gets the messages.
        /// </summary>
        /// <value>
        /// The messages.
        /// </value>
        [DataMember(Name = "messages")]
        public IEnumerable<ResultMessage> Messages => _messages;

        /// <summary>
        /// Adds the result message.
        /// </summary>
        /// <param name="messageType">Type of the message.</param>
        /// <param name="code">The code.</param>
        /// <param name="message">The message.</param>
        public void AddResultMessage(ResultMessageType messageType, string code, string message) =>
            _messages.Add(new ResultMessage(messageType, code, message));
    }

    [DataContract]
    public class CommandResult<T> : CommandResult where T : new()
    {
        [DataMember(Name = "resource")]
        public T Resource { get; }

        public CommandResult(T resource, bool accepted, string url)
            : base(accepted, url)
        {
            Resource = resource;
        }
    }
}
