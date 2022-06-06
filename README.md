# AITSYS.Mailcow

A Mailcow Library written in C# for .NET.

## Installing
You can install the library from following source:

The latest release is always available on [NuGet](https://www.nuget.org/packages/AITSYS.Mailcow/).

<!--## Documentation
The documentation for the latest version is available at [mc.docs.aitsys.dev](https://mc.docs.aitsys.dev).-->

## Bugs or Feature requests?
All requests are tracked at [aitsys.dev](https://aitsys.dev).

## Latest NuGet Packages
| Package                            | NuGet                                                                                                                                                     |
| ---------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------- |
| AITSYS.Mailcow                     | [![NuGet](https://img.shields.io/nuget/v/AITSYS.Mailcow.svg?label=)](https://www.nuget.org/packages/AITSYS.Mailcow)                                       |

## Releasing
To release a new version do the following steps:
- Create locally a repo named `release/VERSION` (Don't forget to replace VERSION with the target version number)
- Replace version number with the correct version in [appveyor.yml#L76](https://github.com/Aiko-IT-Systems/AITSYS.Mailcow/blob/main/appveyor.yml#L76) with the new release number and [appveyor.yml#L5](https://github.com/Aiko-IT-Systems/AITSYS.Mailcow/blob/main/appveyor.yml#L5) with the next-ahead release number.
- Replace nuget version number in [Targets/Version.targets#L4](https://github.com/Aiko-IT-Systems/AITSYS.Mailcow/blob/main/Targets/Version.targets#L4)
- Publish branch to GitHub
- Wait for the CI/CD to complete.
- Merge the branch into main and delete it afterwards

## Thanks
Big thanks goes to the people who helps us ♥️
