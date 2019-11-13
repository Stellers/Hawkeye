using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text;

namespace Stellers.Hawkeye.Web.Filters.Swagger
{
	/// <summary>
	/// A Swagger filter used to allow the ability to have multiple operations with same HTTP verb
	/// </summary>
	/// <seealso cref="Swashbuckle.Swagger.IOperationFilter" />
	public class MultipleOperationsWithSameVerbFilter : IOperationFilter
	{
		/// <summary>
		/// Applies the specified <paramref name="operation" />.
		/// </summary>
		/// <param name="operation">The <paramref name="operation" />.</param>
		/// <param name="context">The schema registry.</param>
		public void Apply(Operation operation, OperationFilterContext context)
		{
			if (operation.Parameters == null)
			{
				return;
			}

			operation.OperationId += "By";
			var builder = new StringBuilder();
			builder.Append(operation.OperationId);
			foreach (var parameter in operation.Parameters)
			{
				builder.Append(parameter.Name);
			}
			operation.OperationId = builder.ToString();
		}
	}
}