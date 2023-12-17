namespace Lab5.Application.Models.ActionResults;

public record ActionResult(
    bool IsSuccess,
    string ErrorMessage = "");