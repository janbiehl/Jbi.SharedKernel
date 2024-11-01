using System.Diagnostics.CodeAnalysis;
using OneOf;
using OneOf.Types;

namespace Jbi.SharedKernel;

/// <summary>
/// Generic result implementation using an oneof approach
/// </summary>
/// <typeparam name="T">Generic Success type</typeparam>
public class Result<T> : OneOfBase<DomainError, Success<T>>
{
	/// <inheritdoc />
	protected Result(OneOf<DomainError, Success<T>> input) : base(input)
	{
		
	}
	
	/// <summary>
	/// True when the operation was a success
	/// </summary>
	[MemberNotNullWhen(true, nameof(Value))]
	[MemberNotNullWhen(false, nameof(DomainError))]
	public bool IsSuccess => IsT1;

	/// <summary>
	/// True when the operation was an error
	/// </summary>
	[MemberNotNullWhen(true, nameof(DomainError))]
	[MemberNotNullWhen(false, nameof(Value))]
	public bool IsFailure => IsT0;
	
	public DomainError? DomainError => IsT0 ? AsT0 : null; 
	
	public new T? Value => IsT1 ? AsT1.Value : default;
	
	public static implicit operator Result<T>(DomainError error) => new (error);
	public static implicit operator Result<T>(T value) => new (new Success<T>(value));

	public static Result<T> Error(DomainError error) => new (error); 
	public static Result<T> Success(T value) => new (new Success<T>(value));
}

/// <summary>
/// Result implementation using an oneof approach
/// </summary>
public sealed class Result : Result<Result>
{
	/// <inheritdoc />
	private Result(OneOf<DomainError, Success<Result>> input) : base(input)
	{
	}

	public static implicit operator Result(DomainError error) => new (error);

	public new static Result Error(DomainError error) => new (error);
	public static Result Success() => new (new Success<Result>());
}
