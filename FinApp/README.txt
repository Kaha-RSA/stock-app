
# Stocks CRUD App

I built a basic CRUD app to solidify my understanding of C# .NET fundamentals including  REST Endpoints​, Entity Framework (EF)​, Models​, Interfaces​, Dependency Injection​, Logging​, Services​, Service Extensions. 


## Acknowledgements

 - [ASP.NET Core Web API .NET 8 Tutorial](https://www.youtube.com/watch?v=qBTe6uHJS_Y&list=PL82C6-O4XrHfrGOCPmKmwTO7M0avXyQKc)

## Authors

- [@JuanBiljoen](https://github.com/JuanBiljoen)


## Steps

1. **Create a Model:**
   - Define a model class that represents the structure of the data you want in your table.

2. **Entity Framework DbContext:**
   - Create a DbContext class that inherits from DbContext. This class will represent your database context and include DbSet properties for your models.

3. **Add Migration:**
   - Open a Command Prompt or Terminal.
   - Navigate to the root folder of your project.
   - Run the following command to add a migration. Replace YourMigrationName with a meaningful name for your migration:

     ```bash
     dotnet ef migrations add YourMigrationName
     ```

   This command will analyze changes in your DbContext and generate the necessary migration code.

4. **Apply Migration:**
   - Run the following command to apply the migration to the database:

     ```bash
     dotnet ef database update
     ```

   This command will update the database schema based on the migration.

5. **Controllers:**
   - Create controllers to handle CRUD operations. These controllers will interact with the database through your DbContext.

6. **Dtos:**
   - Create Data Transfer Objects (DTOs) if needed to shape data for API responses.

7. **CRUD Operations in Controller:**
   - Implement CRUD operations in your controllers, using your DbContext to interact with the database.

8. **Repository Pattern + Dependency Injection (DI):**
   - Optionally, refactor your controllers to use a repository pattern for better separation of concerns and dependency injection.

9. **Refactor to Repository:**
   - If you haven't already, refactor your controllers to use repositories for data access.

// GOING FORWARD (use repositories in controllers for data access)

// Step 1: Create Interface for Repository 
// Add one method to start building infrastructure e.g GetAllAsync()

public interface ICommentRepository
{
    Task<List<Comment>> GetAllAsync();
}

// Step 2: Create the Repository
// Inherit from the Interface created in the step above (Ctrl + . to implement interface) 
// Inject DBContext via constructor ID 

public class CommentRepository : ICommentRepository
{
    private readonly ApplicationDBContext _context;
    
    public CommentRepository(ApplicationDBContext context)
    {
        _context = context;
    }

    public async Task<List<Comment>> GetAllAsync()
    {
        return await _context.Comments.ToListAsync();
    }
}

// Step 3: Add DI for this in Program.cs
builder.Services.AddScoped<ICommentRepository, CommentRepository>();

// Step 4: Create Controller
// Inherit from ControllerBase before adding annotations 
// Bring in Repository via constructor ID

[Route("api/comments")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly ICommentRepository _commentRepo;

    public CommentController(ICommentRepository commentRepo) 
    {
        _commentRepo = commentRepo;
    }

    // Step 5: Add Get Controller etc

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var comments = await _commentRepo.GetAllAsync();

        var commentDto = comments.Select(s => s.ToCommentDto());

        return Ok(commentDto);
    }

    // Step 6: Create DTO from Model for Repository

    public class CommentDto
    {
        // Define properties based on what you want to expose
        public int Id { get; set; }
        public string Title { get; set; }
        // ... other properties
    }

    // Step 7: Create Mapper 

 public static class StockMappers
{
    public static StockDto ToStockDto(this Stock stockModel)
    {
        return new StockDto
        {
            Id = stockModel.Id,
            Symbol = stockModel.Symbol,
            CompanyName = stockModel.CompanyName,
            Purchase = stockModel.Purchase,
            LastDiv = stockModel.LastDiv,
            Industry = stockModel.Industry,
            MarketCap = stockModel.MarketCap,
            Comments = stockModel.Comments.Select(c => c.ToCommentDto()).ToList()
        };
    }
}

    // Step 8: Complete Get Controller 

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var comments = await _commentRepo.GetAllAsync();

        var commentDto = comments.Select(s => s.ToCommentDto());

        return Ok(commentDto);
    }

    // Step 9: Test

    // Add an object in MSSM
    // Test get in Swagger 
}

