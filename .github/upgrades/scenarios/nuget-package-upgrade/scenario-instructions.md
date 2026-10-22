# NuGet Package Upgrade

## Strategy
Inspect all projects and update only vulnerable, outdated, or incompatible NuGet packages to the latest stable versions supported by net10.0, with minimal safe changes.

## Preferences
- **Flow Mode**: Automatic
- **Commit Strategy**: Manual
- **Scope**: TwitterClone.slnx (TwitterClone.Api, TwitterClone.Domain, TwitterClone.Test)
- **Target Framework**: net10.0
- **Version Policy**: Latest stable supported version when an upgrade is justified
- **Preserve Unrelated Changes**: Yes

## Source Control
- **Source Branch**: feature/polymorphism-and-interfaces
- **Working Branch**: feature/polymorphism-and-interfaces
- **Pending Changes**: Preserve; do not commit or discard unrelated changes
- **Commit Strategy**: Manual
- **Branch Sync**: Disabled

## Decisions
- Proceed without an interactive confirmation because the user explicitly requested direct fixes without asking.
- The direct packages Microsoft.AspNetCore.OpenApi 10.0.13 and Microsoft.VisualStudio.Web.CodeGeneration.Design 10.0.2 are already current for net10.0; no direct version bump is needed.
- Restore identified vulnerable transitive NuGet.Packaging and NuGet.Protocol 6.12.1; pin both directly and privately to stable 7.9.0 in TwitterClone.Api.
- The updated graph exposed vulnerable System.Security.Cryptography.Pkcs 8.0.1; pin it directly and privately to stable 10.0.13 in TwitterClone.Api.
- No Central Package Management file exists; package changes belong in TwitterClone.Api.csproj.
- Validate restore, warning-free solution build, and TwitterClone.Test execution. Do not commit or discard unrelated user changes.
