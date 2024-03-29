namespace gamevault.Exceptions;

public class FailedToSaveGameOnDbException : Exception
{

    public FailedToSaveGameOnDbException(string message) : base(message)
    {
    }
    
}