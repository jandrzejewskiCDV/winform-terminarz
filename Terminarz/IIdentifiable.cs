namespace Terminarz
{
    internal interface IIdentifiable<TIdentifier>
    {
        TIdentifier Identifier { get; }
    }
}
