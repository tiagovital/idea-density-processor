namespace Domain.Model
{
    using System;

    public interface IEntity
    {
        Guid Id { get; set; }

        DateTime CreatedAt { get; set; }

        string CreatedBy { get; set; }
    }
}