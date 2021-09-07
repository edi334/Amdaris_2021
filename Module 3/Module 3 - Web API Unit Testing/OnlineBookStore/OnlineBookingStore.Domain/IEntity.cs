namespace OnlineBookStore.Domain
{
    interface IEntity<TId>
    {
        TId Id { get; set; }
    }
}
