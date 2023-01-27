using Financify.Common.Authentication.Hashing;
using Financify.Common.Generators.Random;
using Moq;

namespace Financify.Tests.Common.Authentication.Hashing;

/// <summary>
///     Tests for the <see cref="HashSaltHandler" /> class.
/// </summary>
public class HashSaltHandlerTests
{
    private readonly HashSaltHandler _hashSaltHandler;

    public HashSaltHandlerTests()
    {
        _hashSaltHandler = new HashSaltHandler();
    }

    [Fact(DisplayName = "GenerateHashSalt when called returns HashSalt")]
    public void GenerateHashSalt_WhenCalled_ReturnsHashSalt()
    {
        var result = _hashSaltHandler.GenerateHashSalt("test", 10);
        Assert.NotNull(result);
    }

    [Fact(DisplayName = "GenerateHashSalt uses SHA256 as default algorithm")]
    public void GenerateHashSalt_UsesSHA256_AsDefault()
    {
        var randomStringMock = new Mock<IRandomStringGenerator>();
        randomStringMock.Setup(x => x.Generate(It.IsAny<int>())).Returns("");
        _hashSaltHandler.RandomStringGenerator = randomStringMock.Object;

        var result = _hashSaltHandler.GenerateHashSalt("", 0);
        Assert.Equal(HashAlgorithms.Sha256(""), result.Hash);
    }

    [Fact(DisplayName = "GenerateHashSalt uses given algorithm")]
    public void GenerateHashSalt_UsesGivenAlgorithm()
    {
        var randomStringMock = new Mock<IRandomStringGenerator>();
        randomStringMock.Setup(x => x.Generate(It.IsAny<int>())).Returns("");
        _hashSaltHandler.RandomStringGenerator = randomStringMock.Object;

        var result = _hashSaltHandler.GenerateHashSalt("", 0, HashAlgorithms.Sha256);
        Assert.Equal(HashAlgorithms.Sha256(""), result.Hash);
    }

    [Fact(DisplayName = "GenerateHashSalt uses given salt")]
    public void GenerateHashSalt_UsesGivenSalt()
    {
        const string text = "example text";
        const string salt = "example salt";

        var randomStringMock = new Mock<IRandomStringGenerator>();
        randomStringMock.Setup(x => x.Generate(It.IsAny<int>()))
            .Returns(salt);

        _hashSaltHandler.RandomStringGenerator = randomStringMock.Object;

        var result = _hashSaltHandler.GenerateHashSalt(text, 10);

        const string combined = text + salt;
        var expected = HashAlgorithms.Sha256(combined);

        Assert.Equal(expected, result.Hash);
    }

    [Fact(DisplayName = "GenerateHashSalt uses given salt length")]
    public void GenerateHashSalt_UsesGivenSaltLength()
    {
        const string text = "example text";
        const string salt = "example salt";

        var randomStringMock = new Mock<IRandomStringGenerator>();
        randomStringMock.Setup(x => x.Generate(It.IsAny<int>()))
            .Returns(salt);

        _hashSaltHandler.RandomStringGenerator = randomStringMock.Object;

        _hashSaltHandler.GenerateHashSalt(text, 10);

        randomStringMock.Verify(x => x.Generate(10), Times.Once);
    }

    [Fact(DisplayName = "GenerateHashSalt sets salt")]
    public void GenerateHashSalt_SetsSalt()
    {
        const string text = "example text";
        const string salt = "example salt";

        var randomStringMock = new Mock<IRandomStringGenerator>();
        randomStringMock.Setup(x => x.Generate(It.IsAny<int>()))
            .Returns(salt);

        _hashSaltHandler.RandomStringGenerator = randomStringMock.Object;

        var result = _hashSaltHandler.GenerateHashSalt(text, 10);

        Assert.Equal(salt, result.Salt);
    }
}