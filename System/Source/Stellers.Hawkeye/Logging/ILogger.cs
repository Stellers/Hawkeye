using System;
using System.Collections.Generic;
using Stellers.Hawkeye.Common.Enumerations;

namespace Stellers.Hawkeye.Logging
{
	/// <summary>
	/// Log manager contract for Log instrumentation
	/// </summary>
	///
	public interface ILogger
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="category"></param>
		/// <param name="messageTemplate"></param>
		/// <param name="additionalProperties"></param>
		void Verbose(Log.Category category, string messageTemplate, IDictionary<string, object> additionalProperties = null, params object[] propertyValues);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="category"></param>
		/// <param name="exception"></param>
		/// <param name="additionalProperties"></param>
		void Verbose(Log.Category category, Exception exception, IDictionary<string, object> additionalProperties = null);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="category"></param>
		/// <param name="messageTemplate"></param>
		/// <param name="exception"></param>
		/// <param name="additionalProperties"></param>
		void Verbose(Log.Category category, string messageTemplate, Exception exception, IDictionary<string, object> additionalProperties = null, params object[] propertyValues);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="category"></param>
		/// <param name="messageTemplate"></param>
		/// <param name="additionalProperties"></param>
		void Debug(Log.Category category, string messageTemplate, IDictionary<string, object> additionalProperties = null, params object[] propertyValues);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="category"></param>
		/// <param name="exception"></param>
		/// <param name="additionalProperties"></param>
		void Debug(Log.Category category, Exception exception, IDictionary<string, object> additionalProperties = null);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="category"></param>
		/// <param name="messageTemplate"></param>
		/// <param name="exception"></param>
		/// <param name="additionalProperties"></param>
		void Debug(Log.Category category, string messageTemplate, Exception exception, IDictionary<string, object> additionalProperties = null, params object[] propertyValues);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="category"></param>
		/// <param name="messageTemplate"></param>
		/// <param name="additionalProperties"></param>
		void Information(Log.Category category, string messageTemplate, IDictionary<string, object> additionalProperties = null, params object[] propertyValues);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="category"></param>
		/// <param name="exception"></param>
		/// <param name="additionalProperties"></param>
		void Information(Log.Category category, Exception exception, IDictionary<string, object> additionalProperties = null);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="category"></param>
		/// <param name="messageTemplate"></param>
		/// <param name="exception"></param>
		/// <param name="additionalProperties"></param>
		void Information(Log.Category category, string messageTemplate, Exception exception, IDictionary<string, object> additionalProperties = null, params object[] propertyValues);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="category"></param>
		/// <param name="messageTemplate"></param>
		/// <param name="additionalProperties"></param>
		void Warning(Log.Category category, string messageTemplate, IDictionary<string, object> additionalProperties = null, params object[] propertyValues);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="category"></param>
		/// <param name="exception"></param>
		/// <param name="additionalProperties"></param>
		void Warning(Log.Category category, Exception exception, IDictionary<string, object> additionalProperties = null);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="category"></param>
		/// <param name="messageTemplate"></param>
		/// <param name="exception"></param>
		/// <param name="additionalProperties"></param>
		void Warning(Log.Category category, string messageTemplate, Exception exception, IDictionary<string, object> additionalProperties = null, params object[] propertyValues);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="severity"></param>
		/// <param name="category"></param>
		/// <param name="messageTemplate"></param>
		/// <returns></returns>
		string Error(Log.Category category, string messageTemplate, IDictionary<string, object> additionalProperties = null, params object[] propertyValues);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="severity"></param>
		/// <param name="category"></param>
		/// <param name="exception"></param>
		/// <param name="additionalProperties"></param>
		/// <returns></returns>
		string Error(Log.Category category, Exception exception, IDictionary<string, object> additionalProperties = null);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="severity"></param>
		/// <param name="category"></param>
		/// <param name="messageTemplate"></param>
		/// <param name="exception"></param>
		/// <param name="additionalProperties"></param>
		/// <returns></returns>
		string Error(Log.Category category, string messageTemplate, Exception exception, IDictionary<string, object> additionalProperties = null, params object[] propertyValues);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="category"></param>
		/// <param name="messageTemplate"></param>
		/// <param name="additionalProperties"></param>
		string Fatal(Log.Category category, string messageTemplate, IDictionary<string, object> additionalProperties = null, params object[] propertyValues);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="category"></param>
		/// <param name="exception"></param>
		/// <param name="additionalProperties"></param>
		string Fatal(Log.Category category, Exception exception, IDictionary<string, object> additionalProperties = null);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="category"></param>
		/// <param name="messageTemplate"></param>
		/// <param name="exception"></param>
		/// <param name="additionalProperties"></param>
		string Fatal(Log.Category category, string messageTemplate, Exception exception, IDictionary<string, object> additionalProperties = null, params object[] propertyValues);
	}
}