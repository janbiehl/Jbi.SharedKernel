namespace Jbi.SharedKernel;

/// <summary>
/// Error codes that will be used by the domain error
/// </summary>
public static class DomainErrorCodes
{
	/// <summary>
	/// A unspecified common error
	/// </summary>
	public const int CommonErrorCode = 1;

	/// <summary>
	/// A error that indicates that a resource was not found
	/// </summary>
	public const int NotFoundErrorCode = 10;

	/// <summary>
	/// A error that indicates that a validation has failed
	/// </summary>
	public const int InvalidErrorCode = 11;
}