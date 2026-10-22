# NuGet Package Upgrade Plan

## Overview

**Target**: Resolve NuGet restore vulnerability warnings and verify package compatibility across the .NET 10 TwitterClone solution.
**Scope**: 3 projects in `TwitterClone.slnx`; only `TwitterClone.Api` currently declares NuGet packages, while Domain and Test use project references only.

## Tasks

### 01-secure-transitive-nuget-dependencies: Secure vulnerable NuGet transitive dependencies

The assessment found the direct packages `Microsoft.AspNetCore.OpenApi` 10.0.13 and `Microsoft.VisualStudio.Web.CodeGeneration.Design` 10.0.2 already at the latest stable versions supported by `net10.0`. Restore surfaced low-severity NU1901 advisories for transitive `NuGet.Packaging` and `NuGet.Protocol` 6.12.1. Add minimal direct private package pins for the secure stable 7.9.0 versions so the code-generation dependency graph resolves without those advisories, then restore and validate all projects.

No source API changes are expected from the direct package assessment; use build output to detect any compatibility issue. Preserve the user's existing `TwitterClone.slnx` and `TwitterClone.Api` changes.

**Done when**: `NuGet.Packaging` and `NuGet.Protocol` resolve to 7.9.0 without NU1901 warnings; all three projects restore and build with zero warnings/errors; the test project executes successfully; existing unrelated changes remain intact.
