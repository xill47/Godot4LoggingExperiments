{
  description = "Godot 4.5 + .NET SDK development shell";

  inputs = {
    nixpkgs.url = "github:NixOS/nixpkgs/nixos-unstable";
  };

  outputs = { nixpkgs, ... }:
    let
      systems = [
        "x86_64-linux"
        "aarch64-linux"
        "x86_64-darwin"
        "aarch64-darwin"
      ];
      forAllSystems = nixpkgs.lib.genAttrs systems;
    in
    {
      devShells = forAllSystems (system:
        let
          pkgs = import nixpkgs { inherit system; };
        in
        {
          default = pkgs.mkShell {
            packages = with pkgs; [
              (godot_4_5-mono.overrideAttrs {
                dotnet-sdk = dotnet-sdk_10;
              })
            ];
            shellHook = ''
              alias godot=godot-mono

              dotnet --version
              godot-mono --version
            '';
          };
        });
    };
}
