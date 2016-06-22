# EquationParser

An example of an equation parser built for Unity using GPPG and GPLEX.

It's a simple game where targets move across the screen from left to right and the player must tap them. The equation parser is used to parse equations entered that determine the y coordinate of the target as it moves across the screen.

## Presentation and Additional Notes

This repository was uploaded as an example for the presentation I gave at the Unity Vancouver Meetup in June of 2016 titled "Unity Tools Toolbox: Creating a Domain Specific Language".

The presentation should give some context for the project, and this readme has some additional notes for the presentation in the subheadings of this section.

### How to use GPPG and GPLEX for your own project

There are 3 things that you will need to do if you want to use GPPG and GPLEX.

1. Add ShiftReduceParserCode.cs to your project.

2. Add `EXPORT_GPPG` to your Scripting Define Symbols in the Player Settings of Unity.

3. Make sure to define a constructor in your `.y` file like this:

        %{ 
            public Parser(Scanner scanner) : base(scanner) {} 
        }%
    You need at least this constructor.

### Invoking GPPG and GPLEX

GPLEX is quite straightforward:

`gplex [Scanner Config File]`

Where `[Scanner Config File]` is the scanner configuration file, or `.lex` file.

GPPG has a weirder method of calling it:

`Gppg.exe /gplex [Parser Config File] > [Output File]`

Where `[Parser Config File]` is the `.y` parser configuration file, and `[Output File]` is a `.cs` file.

### Common GPPG and GPLEX Issues

#### `shift/reduce conflict`
Your parser rules can be interpreted in a few ways (eg. is `a + b + c` parsed as `a + b` `+ c` or `a +` `b + c`?). You can usually resolve this by replacing problematic `%token`s with either `%left` or `%right` to specify precedence.

### Other Tips

- The layout of `.y` or `.lex` files is kind of complicated. I would suggest keeping an example open to copy from.

- A particularly helpful example of using GPPG and GPLEX is [IronScheme](https://github.com/leppie/IronScheme/tree/master/IronScheme/IronScheme/Compiler).

## Structure

### Main Scene
The `BattleController` is responsible for spawning `Target`s, and contains a list of `TargetData`s that will be used during gameplay.

### Important Folders
- `Data/Features/Targets` - The `TargetData` assets.
- `Media` - Images and prefabs
- `Scripts/Features/Battle` - Contains the `BattleController` class.
- `Scripts/Features/Targets` - Contains the `Target` and `TargetData` classes.
- `Scripts/Features/Equations` - Contains files related to compiling and evaluating equations.
