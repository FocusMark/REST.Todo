using FluentValidation;
using FocusMark.Tasks.Domain;
using System;
using System.Text.RegularExpressions;

namespace FocusMark.Tasks.Application.TasksLists.Commands
{

    public class CreateTaskListCommandValidator : AbstractValidator<CreateTaskListCommand>
    {
        public CreateTaskListCommandValidator()
        {
            RuleFor(command => command.Title)
                .NotEmpty().WithMessage($"{nameof(CreateTaskListCommand.Title)} is required.")
                .MaximumLength(200).WithMessage($"{nameof(CreateTaskListCommand.Title)} must not exceed 200 characters");

            RuleFor(command => command.Color)
                .Must(MatchExpectedPattern).WithMessage($"{nameof(CreateTaskListCommand.Color)} must match the pattern of {TaskList.HexColorRegEx}");
        }

        public bool MatchExpectedPattern(string hexColor)
        {
            if (string.IsNullOrEmpty(hexColor))
            {
                return false;

            }
            return Regex.IsMatch(hexColor, TaskList.HexColorRegEx);
        }
    }
}
