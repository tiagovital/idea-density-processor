namespace Domain.Model
{
    using System;

    public interface IEntity
    {
        string Id { get; set; }

        DateTime CreatedAt { get; set; }

        string CreatedBy { get; set; }
    }
}