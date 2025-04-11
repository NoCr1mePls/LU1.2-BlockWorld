using System;

namespace Dtos
{
    public class Environment2DDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }

        public override string ToString()
        {
            return $"\nId: {Id}\nName: {Name}\nUserId: {UserId}";
        }
    }
}