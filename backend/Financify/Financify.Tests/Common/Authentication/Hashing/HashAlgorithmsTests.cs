using Financify.Common.Authentication.Hashing;

namespace Financify.Tests.Common.Authentication.Hashing;

/// <summary>
///     Tests for the <see cref="HashAlgorithms" /> class.
/// </summary>
public class HashAlgorithmsTests
{
    [Theory]
    [InlineData("", "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855")]
    [InlineData(" ", "36a9e7f1c95b82ffb99743e0c5c4ce95d83c9a430aac59f84ef3cbfab6145068")]
    [InlineData("example value", "2f9929778ab5a22dcef412ccbf37b950c0f8e76889d2ec19866290c674c78b1a")]
    public void Sha256_WhenCalled_ReturnsHash(string value, string expected)
    {
        var result = HashAlgorithms.Sha256(value);
        Assert.Equal(expected, result);
    }
}