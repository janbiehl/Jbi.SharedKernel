using System.Text;

namespace Jbi.SharedKernel;

/// <summary>
/// Defines an error that is expected to happen inside the domain
/// </summary>
public record DomainError(int Code, string Message)
{
	/// <summary>
	/// Error code to indicate what kind of error happened
	/// </summary>
	public int Code { get; private set; } = Code;

	/// <summary>
	/// Describes the error further
	/// </summary>
	public string Message { get; private set; } = Message;

	/// <summary>
	/// Create a common domain error with a custom message. The message is crucial
	/// </summary>
	/// <param name="message">The error message</param>
	/// <returns>The new domain error</returns>
	public static DomainError Error(string message)
	{
		return new DomainError(DomainErrorCodes.CommonErrorCode, message);
	}

	/// <summary>
	/// Create a domain error that indicates that a resource was not found
	/// </summary>
	/// <param name="message">Optional error description</param>
	/// <returns>The new domain error</returns>
	public static DomainError NotFound(string? message = default)
	{
		return new DomainError(DomainErrorCodes.NotFoundErrorCode, message ?? "not found");
	}

	/// <summary>
	/// Create a domain error that indicates that the validation failed
	/// </summary>
	/// <param name="validationErrors">The errors that occured during validation</param>
	/// <param name="message">Header message</param>
	/// <returns>The new domain error</returns>
	public static DomainError Invalid(IEnumerable<(string field, string message)> validationErrors,
		string? message = default)
	{
		StringBuilder builder = new ();
		builder.AppendLine(message ?? "Validation errors");

		foreach (var (field, error) in validationErrors)
		{
			builder.AppendLine($" - {field}: {error}");
		}

		return new DomainError(DomainErrorCodes.InvalidErrorCode, builder.ToString());
	}

	/// <summary>
	/// Create a domain error that indicates that a user is not authorized
	/// </summary>
	/// <returns>The new domain error</returns>
	public static DomainError Unauthorized()
	{
		return new DomainError(DomainErrorCodes.UnauthorizedErrorCode, "Unauthorized");
	}

	/// <inheritdoc />
	public override string ToString()
	{
		return Message;
	}
}