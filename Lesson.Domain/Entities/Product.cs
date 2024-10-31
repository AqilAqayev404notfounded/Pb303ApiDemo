using Academy.Domain.Entities;
using Core.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.Entities;

public class Product : Entity
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string CategoryId { get; set; }
    public Category Category { get; set; }

}
public class AppUser : IdentityUser
{
    public required string FullName { get; set; }


}
