using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace Stellers.Hawkeye.Common.Exceptions
{
	/// <summary>
	/// Represents a error response.
	/// </summary>
	[DataContract]
	public class FriendlyError
	{
		/// <summary>
		/// Gets or sets the error key.
		/// </summary>
		/// <value>The key.</value>
		[DataMember(EmitDefaultValue = false)]
		public string Key { get; set; }

		/// <summary>
		/// Gets or sets the error message.
		/// </summary>
		/// <value>The message.</value>
		[DataMember(EmitDefaultValue = false)]
		public string Message { get; set; }

		/// <summary>
		/// Gets or sets the optional data element this error applies to.
		/// </summary>
		/// <value>
		/// The property name.
		/// </value>
		[DataMember(EmitDefaultValue = false)]
		public string DataElement { get; set; }

		/// <summary>
		/// Gets or sets the HTTP status code that should be used for this error.
		/// </summary>
		/// <value>
		/// The HTTP status code.
		/// </value>
		[IgnoreDataMember]
		public HttpStatusCode HttpStatusCode { get; set; }

		/// <summary>
		/// Gets or sets the diagnostics correlation id that corresponds to this request.
		/// </summary>
		/// <value>
		/// The correlation id.
		/// </value>
		[DataMember(EmitDefaultValue = false)]
		public string CorrelationId { get; set; }

		/// <summary>
		/// Gets or sets the exception.
		/// </summary>
		/// <value>
		/// The exception.
		/// </value>
		[DataMember(EmitDefaultValue = false)]
		public Exception Exception { get; private set; }
		
		/// <summary>
		/// Sets the exception, only in Development mode.
		/// </summary>
		/// <param name="exception">The exception.</param>
		public void SetException(IHostingEnvironment hostingEnvironment, Exception exception)
		{
			if (hostingEnvironment.IsDevelopment())
			{
				Exception = exception;
			}
		}
	}
}