using System;
using System.Collections.Generic;

namespace Stellers.Hawkeye.Logging
{
	/// <summary>
	/// 
	/// </summary>
	public class Logger : ILogger
	{
		/// <summary>
		/// 
		/// </summary>
		readonly Serilog.ILogger _logger;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="logger"></param>
		public Logger(Serilog.ILogger logger)
		{
			_logger = logger;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="category"></param>
		/// <param name="messageTemplate"></param>
		/// <param name="additionalProperties"></param>
		/// <param name="propertyValues"></param>
		public void Debug(Common.Enumerations.Log.Category category, string messageTemplate, IDictionary<string, object> additionalProperties = null, params object[] propertyValues)
		{
			AddToContext(_logger, category, additionalProperties).Debug(messageTemplate, propertyValues);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="category"></param>
		/// <param name="exception"></param>
		/// <param name="additionalProperties"></param>
		public void Debug(Common.Enumerations.Log.Category category, Exception exception, IDictionary<string, object> additionalProperties = null)
		{
			AddToContext(_logger, category, additionalProperties).Debug(exception, exception.Message);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="category"></param>
		/// <param name="messageTemplate"></param>
		/// <param name="exception"></param>
		/// <param name="additionalProperties"></param>
		/// <param name="propertyValues"></param>
		public void Debug(Common.Enumerations.Log.Category category, string messageTemplate, Exception exception, IDictionary<string, object> additionalProperties = null, params object[] propertyValues)
		{
			AddToContext(_logger, category, additionalProperties).Debug(exception, messageTemplate, propertyValues);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="category"></param>
		/// <param name="messageTemplate"></param>
		/// <param name="additionalProperties"></param>
		/// <param name="propertyValues"></param>
		/// <returns></returns>
		public string Error(Common.Enumerations.Log.Category category, string messageTemplate, IDictionary<string, object> additionalProperties = null, params object[] propertyValues)
		{
			var corelationId = GetCorelationId;
			AddToContext(_logger, category, additionalProperties)
				   .ForContext(nameof(corelationId), corelationId)
				   .Error(messageTemplate, propertyValues);
			return corelationId;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="category"></param>
		/// <param name="exception"></param>
		/// <param name="additionalProperties"></param>
		/// <returns></returns>
		public string Error(Common.Enumerations.Log.Category category, Exception exception, IDictionary<string, object> additionalProperties = null)
		{
			var corelationId = GetCorelationId;
			AddToContext(_logger, category, additionalProperties)
				   .ForContext(nameof(corelationId), corelationId)
				   .Error(exception, exception.Message);
			return corelationId;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="category"></param>
		/// <param name="messageTemplate"></param>
		/// <param name="exception"></param>
		/// <param name="additionalProperties"></param>
		/// <param name="propertyValues"></param>
		/// <returns></returns>
		public string Error(Common.Enumerations.Log.Category category, string messageTemplate, Exception exception, IDictionary<string, object> additionalProperties = null, params object[] propertyValues)
		{
			var corelationId = GetCorelationId;
			AddToContext(_logger, category, additionalProperties)
				   .ForContext(nameof(corelationId), corelationId)
				   .Error(exception, messageTemplate, propertyValues);
			return corelationId;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="category"></param>
		/// <param name="messageTemplate"></param>
		/// <param name="additionalProperties"></param>
		/// <param name="propertyValues"></param>
		/// <returns></returns>
		public string Fatal(Common.Enumerations.Log.Category category, string messageTemplate, IDictionary<string, object> additionalProperties = null, params object[] propertyValues)
		{
			var corelationId = GetCorelationId;
			AddToContext(_logger, category, additionalProperties)
				   .ForContext(nameof(corelationId), corelationId)
				   .Fatal(messageTemplate, propertyValues);
			return corelationId;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="category"></param>
		/// <param name="exception"></param>
		/// <param name="additionalProperties"></param>
		/// <returns></returns>
		public string Fatal(Common.Enumerations.Log.Category category, Exception exception, IDictionary<string, object> additionalProperties = null)
		{
			var corelationId = GetCorelationId;
			AddToContext(_logger, category, additionalProperties)
				   .ForContext(nameof(corelationId), corelationId)
				   .Fatal(exception, exception.Message);
			return corelationId;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="category"></param>
		/// <param name="messageTemplate"></param>
		/// <param name="exception"></param>
		/// <param name="additionalProperties"></param>
		/// <param name="propertyValues"></param>
		/// <returns></returns>
		public string Fatal(Common.Enumerations.Log.Category category, string messageTemplate, Exception exception, IDictionary<string, object> additionalProperties = null, params object[] propertyValues)
		{
			var corelationId = GetCorelationId;
			AddToContext(_logger, category, additionalProperties)
				   .ForContext(nameof(corelationId), corelationId)
				   .Fatal(exception, messageTemplate, propertyValues);
			return corelationId;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="category"></param>
		/// <param name="messageTemplate"></param>
		/// <param name="additionalProperties"></param>
		/// <param name="propertyValues"></param>
		public void Information(Common.Enumerations.Log.Category category, string messageTemplate, IDictionary<string, object> additionalProperties = null, params object[] propertyValues)
		{
			AddToContext(_logger, category, additionalProperties).Information(messageTemplate, propertyValues);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="category"></param>
		/// <param name="exception"></param>
		/// <param name="additionalProperties"></param>
		public void Information(Common.Enumerations.Log.Category category, Exception exception, IDictionary<string, object> additionalProperties = null)
		{
			AddToContext(_logger, category, additionalProperties).Information(exception, exception.Message);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="category"></param>
		/// <param name="messageTemplate"></param>
		/// <param name="exception"></param>
		/// <param name="additionalProperties"></param>
		/// <param name="propertyValues"></param>
		public void Information(Common.Enumerations.Log.Category category, string messageTemplate, Exception exception, IDictionary<string, object> additionalProperties = null, params object[] propertyValues)
		{
			AddToContext(_logger, category, additionalProperties).Information(exception, messageTemplate, propertyValues);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="category"></param>
		/// <param name="messageTemplate"></param>
		/// <param name="additionalProperties"></param>
		/// <param name="propertyValues"></param>
		public void Verbose(Common.Enumerations.Log.Category category, string messageTemplate, IDictionary<string, object> additionalProperties = null, params object[] propertyValues)
		{
			AddToContext(_logger, category, additionalProperties).Information(messageTemplate, propertyValues);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="category"></param>
		/// <param name="exception"></param>
		/// <param name="additionalProperties"></param>
		public void Verbose(Common.Enumerations.Log.Category category, Exception exception, IDictionary<string, object> additionalProperties = null)
		{
			AddToContext(_logger, category, additionalProperties).Information(exception, exception.Message);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="category"></param>
		/// <param name="messageTemplate"></param>
		/// <param name="exception"></param>
		/// <param name="additionalProperties"></param>
		/// <param name="propertyValues"></param>
		public void Verbose(Common.Enumerations.Log.Category category, string messageTemplate, Exception exception, IDictionary<string, object> additionalProperties = null, params object[] propertyValues)
		{
			AddToContext(_logger, category, additionalProperties).Information(exception, messageTemplate, propertyValues);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="category"></param>
		/// <param name="messageTemplate"></param>
		/// <param name="additionalProperties"></param>
		/// <param name="propertyValues"></param>
		public void Warning(Common.Enumerations.Log.Category category, string messageTemplate, IDictionary<string, object> additionalProperties = null, params object[] propertyValues)
		{
			AddToContext(_logger, category, additionalProperties).Warning(messageTemplate, propertyValues);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="category"></param>
		/// <param name="exception"></param>
		/// <param name="additionalProperties"></param>
		public void Warning(Common.Enumerations.Log.Category category, Exception exception, IDictionary<string, object> additionalProperties = null)
		{
			AddToContext(_logger, category, additionalProperties).Information(exception, exception.Message);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="category"></param>
		/// <param name="messageTemplate"></param>
		/// <param name="exception"></param>
		/// <param name="additionalProperties"></param>
		/// <param name="propertyValues"></param>
		public void Warning(Common.Enumerations.Log.Category category, string messageTemplate, Exception exception, IDictionary<string, object> additionalProperties = null, params object[] propertyValues)
		{
			AddToContext(_logger, category, additionalProperties).Information(exception, messageTemplate, propertyValues);
		}

		/// <summary>
		/// 
		/// </summary>
		private string GetCorelationId => Guid.NewGuid().ToString();

		/// <summary>
		/// 
		/// </summary>
		/// <param name="_logger"></param>
		/// <param name="category"></param>
		/// <param name="additionalProperties"></param>
		/// <returns></returns>
		private Serilog.ILogger AddToContext(Serilog.ILogger _logger, Common.Enumerations.Log.Category category, IDictionary<string, object> additionalProperties = null)
		{
			return _logger.ForContext(nameof(category), category)
						  .ForContext(nameof(additionalProperties), additionalProperties, true);
		}
	}
}
