# DisCatSharp.Mailcow [![GitHub](https://img.shields.io/github/license/Aiko-IT-Systems/DisCatSharp.Mailcow?label=License)](https://github.com/Aiko-IT-Systems/DisCatSharp.Mailcow/blob/main/LICENSE.md) [![Sponsors](https://img.shields.io/github/sponsors/Lulalaby?label=Sponsors)](https://github.com/sponsors/Lulalaby) [![Discord Server](https://img.shields.io/discord/858089281214087179.svg?label=Discord)](https://discord.gg/discatsharp)

![dcs-christmas-banner](https://user-images.githubusercontent.com/14029133/144901681-3056a79a-16fd-43ab-956e-b4268c3427e1.jpeg)

[Mailcow Library](https://discord.gg/discatsharp) written in C# for .NET.

#### Status
[![NuGet](https://img.shields.io/nuget/v/DisCatSharp.Mailcow.svg?label=NuGet%20Overall%20Version)](https://www.nuget.org/packages/DisCatSharp.Mailcow/)
[![Build status](https://ci.appveyor.com/api/projects/status/5ui2hbsllu7dh0n3/branch/main?svg=true)](https://ci.appveyor.com/project/AITSYS/discatsharp-mailcow/branch/main)

#### Commit Activities
[![GitHub last commit](https://img.shields.io/github/last-commit/Aiko-IT-Systems/DisCatSharp?label=Last%20Commit)](https://aitsys.dev/source/DisCatSharp/history/)
[![GitHub commit activity](https://img.shields.io/github/commit-activity/w/Aiko-IT-Systems/DisCatSharp?label=Commit%20Activity)](https://github.com/Aiko-IT-Systems/DisCatSharp/commits/main)
[![wakatime](https://wakatime.com/badge/github/Aiko-IT-Systems/DisCatSharp.svg)](https://wakatime.com/badge/github/Aiko-IT-Systems/DisCatSharp)

#### Stats
[![GitHub pull requests](https://img.shields.io/github/issues-pr/Aiko-IT-Systems/DisCatSharp.Mailcow?label=PRs)](https://github.com/Aiko-IT-Systems/DisCatSharp.Mailcow/pulls)
[![GitHub code size in bytes](https://img.shields.io/github/languages/code-size/Aiko-IT-Systems/DisCatSharp.Mailcow?label=Size)](#)
[![GitHub contributors](https://img.shields.io/github/contributors/Aiko-IT-Systems/DisCatSharp.Mailcow)](https://github.com/Aiko-IT-Systems/DisCatSharp.Mailcow/graphs/contributors)
[![GitHub Repo stars](https://img.shields.io/github/stars/Aiko-IT-Systems/DisCatSharp.Mailcow?label=Stars)](https://github.com/Aiko-IT-Systems/DisCatSharp.Mailcow/stargazers)
<!-- [![Known Vulnerabilities](https://snyk.io/test/github/Aiko-IT-Systems/DisCatSharp.Mailcow/badge.svg)](https://snyk.io/test/github/Aiko-IT-Systems/DisCatSharp.Mailcow)-->

## Where is the Changelog?
On our guild! You find it in [this channel](https://discord.com/channels/858089281214087179/858099438580006913).

## Installing
You can install the library from following source:

The latest release is always available on [NuGet](https://www.nuget.org/packages/DisCatSharp.Mailcow/).

## Documentation
The documentation for the latest version is available at [dcsm.aitsys.dev](https://dcsm.aitsys.dev).

## Bugs or Feature requests?
Either join our [support guild](https://discord.gg/discatsharp) and open a support ticket.
Or write a mail to dcs@aitsys.dev.

All requests are tracked at [aitsys.dev](https://aitsys.dev).

<!-- ## Tutorials
* [Howto](https://dcsm.aitsys.dev/articles/preamble.html) -->

## Latest NuGet Packages
| Package                                 | NuGet                                                                                                                                                               |
| --------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| DisCatSharp.Mailcow                     | [![NuGet](https://img.shields.io/nuget/v/DisCatSharp.Mailcow.svg?label=)](https://www.nuget.org/packages/DisCatSharp.Mailcow)                                       |

## Releasing
To release a new version do the following steps:
- Create locally a repo named `release/VERSION` (Don't forget to replace VERSION with the target version number)
- Replace version number with the correct version in [appveyor.yml#L76](https://github.com/Aiko-IT-Systems/DisCatSharp.Mailcow/blob/main/appveyor.yml#L76) with the new release number and [appveyor.yml#L5](https://github.com/Aiko-IT-Systems/DisCatSharp.Mailcow/blob/main/appveyor.yml#L5) with the next-ahead release number.
- Replace nuget version number in [Targets/Version.targets#L4](https://github.com/Aiko-IT-Systems/DisCatSharp.Mailcow/blob/main/Targets/Version.targets#L4)
- Publish branch to GitHub
- Wait for the CI/CD to complete.
- Merge the branch into main and delete it afterwards

## Thanks
Big thanks goes to the people who helps us ♥️
