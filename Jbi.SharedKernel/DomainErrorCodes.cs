namespace Jbi.SharedKernel;

/// <summary>
/// Error codes that will be used by the domain error
/// </summary>
public static class DomainErrorCodes
{
	/// <summary>
	/// An unspecified common error
	/// </summary>
	public const int CommonErrorCode = 1;

	/// <summary>
	/// An error that indicates that a resource was not found
	/// </summary>
	public const int NotFoundErrorCode = 10;

	/// <summary>
	/// An error that indicates that a validation has failed
	/// </summary>
	public const int InvalidErrorCode = 11;
	
	/// <summary>
	/// An error that indicates that the user is not authorized
	/// </summary>
	public const int UnauthorizedErrorCode = 12;
}