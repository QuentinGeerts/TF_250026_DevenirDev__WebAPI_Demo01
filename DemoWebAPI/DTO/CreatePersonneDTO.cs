namespace DemoWebAPI.DTO;

// DTO : Data Transfer Object
public class CreatePersonneDTO
{
    public string Lastname { get; set; }
    public string Firstname { get; set; }
    public DateOnly BirthDate { get; set; }
}

public class PatchLastNameDto
{
    public string Lastname { get; set; }
}