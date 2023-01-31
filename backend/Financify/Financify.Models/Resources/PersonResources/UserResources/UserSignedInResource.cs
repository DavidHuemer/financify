namespace Financify.Models.Resources.PersonResources.UserResources;

public record UserSignedInResource
{
    public required int UserId { get; set; }

    public required string Token { get; set; }
}