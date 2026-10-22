# 01-secure-transitive-nuget-dependencies: Secure vulnerable NuGet transitive dependencies

The assessment found the direct packages `Microsoft.AspNetCore.OpenApi` 10.0.13 and `Microsoft.VisualStudio.Web.CodeGeneration.Design` 10.0.2 already at the latest stable versions supported by `net10.0`. Restore surfaced low-severity NU1901 advisories for transitive `NuGet.Packaging` and `NuGet.Protocol` 6.12.1. Pin those packages to stable 7.9.0. The updated graph then exposed `System.Security.Cryptography.Pkcs` 8.0.1 with moderate/high advisories, so pin it to stable 10.0.13 as well.

No source API changes are expected from the direct package assessment; use build output to detect any compatibility issue. Preserve the user's existing `TwitterClone.slnx` and `TwitterClone.Api` changes.

## Scope Inventory

- **Projects affected**: `TwitterClone.Api` (package references and transitive code-generation dependencies), `TwitterClone.Domain` (project dependency only), and `TwitterClone.Test` (test/build consumer).
- **Package configuration**: `TwitterClone.Api/TwitterClone.Api.csproj` contains the only direct PackageReferences. No `Directory.Packages.props` or central package management was found. `get_project_dependencies` confirmed the direct references are defined in that project file.
- **Current direct packages**: `Microsoft.AspNetCore.OpenApi` 10.0.13 and `Microsoft.VisualStudio.Web.CodeGeneration.Design` 10.0.2; `dotnet list package --outdated` reports no direct updates.
- **Restore findings**: Initial restore emitted NU1901 for transitive `NuGet.Packaging` 6.12.1 and `NuGet.Protocol` 6.12.1, linked to GHSA-g4vj-cjjj-v7hg. After pinning both to 7.9.0, restore exposed `System.Security.Cryptography.Pkcs` 8.0.1 with GHSA-2fmv-rv2c-59x7 and GHSA-846f-f764-76mx; stable 10.0.13 is supported for net10.0.
- **Planned mechanics**: Standard per-project PackageReference mode; add `PrivateAssets=all` and matching `IncludeAssets` metadata so the security pins do not become part of the application API/dependency surface.
- **Validation**: Restore and build the full solution with `dotnet` PowerShell commands, then run `dotnet test TwitterClone.Test/TwitterClone.Test.csproj`; this repo's test project is an executable and may report no discoverable test cases.

**Done when**: `NuGet.Packaging` and `NuGet.Protocol` resolve to 7.9.0 and `System.Security.Cryptography.Pkcs` resolves to 10.0.13 without NU1901/NU1902/NU1903 warnings; all three projects restore and build with zero warnings/errors; the test project executes successfully; existing unrelated changes remain intact.
