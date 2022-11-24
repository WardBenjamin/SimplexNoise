# Simplex Noise

Simplex Noise implementation offering 1D, 2D, and 3D forms w/ values in the range of 0 to 255. Based on work by Heikki Törmälä (2012) and Stefan Gustavson (2006). Core algorithm designed by Ken Perlin (2001). 

[![Nuget](https://img.shields.io/nuget/v/SimplexNoise.svg?logo=nuget)](https://www.nuget.org/packages/SimplexNoise/2.0.0)
[![Nuget](https://img.shields.io/nuget/dt/SimplexNoise.svg)](https://www.nuget.org/packages/SimplexNoise/2.0.0)

### What does this library provide?

This library provides 1D, 2D, and 3D simplex noise, which is useful for procedural content generation - for example, terrain and particles in game development or visual media in movies. Compared to classic Perlin noise, simplex noise has no noticable directional artefacts, and has a well-defined and continuous (coherent) gradient. This means content will be visually smoother, with a lower computational complexity especially at higher orders.

Computations use the following r^2 values to determine kernel contribution:

| Order | Value |
|-------|-------|
| 1D    | 1.0   |
| 2D    | 0.5   |
| 3D    | 0.6   |


### Why use simplex noise?

Classic noise has problems with non-uniformity throughout its domain of definition, particularly for 2D planar slices of 3D and 4D noise, it has visible axis-aligned artefacts, it is expensive to compute for 4D and up, and its derivative in 3D and 4D is a very complicated high order polynomial.

Simplex noise is several times faster to compute, particularly for 4D and up, it does not have nearly as many visual problems with non-uniformity and axis-aligned artefacts, and it has a simple polynomial derivative everywhere, even for higher dimensions.

Simplex noise looks better, but different, and is thus visually incompatible with classic Perlin noise. The difference in feature size and range of values can easily be compensated for by a few simple scaling multiplications, but the different visual character might change the visual result of shaders that depend heavily on one or two components of noise. (Fractal sums of several noise components should still look about the same, though.)

### Example of implementation

```csharp
using SimplexNoise;

Noise.Seed = 209323094; // Optional

int length = 10, width = 15; // The number of points to generate in the 1st and 2nd dimension
float scale = 0.10f; // The scale of the noise. The greater the scale, the denser the noise gets
float[,] noiseValues = Noise.Calc2D(length, width, scale); // Returns an array containing 2D Simplex noise
```

### API

- [Noise.Seed](#noiseseed) - Arbitrary integer seed used to generate lookup table used internally.
- [float\[\] Noise.Calc1D](#noisecalc1d) - returns an array containing 1D Simplex noise
- [float\[,\] Noise.Calc2D](#noisecalc2d) - returns an array containing 2D Simplex noise
- [float\[,,\] Noise.Calc3D](#noisecalc3d) - returns an array containing 3D Simplex noise
- [float Noise.CalcPixel1D](#noisecalcpixel1d) - returns the value of an index of 1D simplex noise
- [float Noise.CalcPixel2D](#noisecalcpixel2d) - returns the value of an index of 2D simplex noise
- [float Noise.CalcPixel3D](#noisecalcpixel3d) - returns the value of an index of 3D simplex noise

#### Noise.Seed

Arbitrary integer seed used to generate lookup table used internally. You can set the `Seed` property to get deterministic noise, otherwise, the `Seed` will default to `0`.

```csharp
Noise.Seed = 123456;
```

#### Noise.Calc1D

Creates 1D Simplex noise.

```csharp
int width = 10; // The number of points to generate
float scale = 0.10f; // The scale of the noise. The greater the scale, the denser the noise gets // The scale of the noise. The greater the scale, the denser the noise gets
float[] noise = Noise.Calc1D(width, scale); // Returns an array containing 1D Simplex noise
```

#### Noise.Calc2D

Creates 2D Simplex noise.

```csharp
int width = 10, height = 15; // The number of points to generate in the 1st and 2nd dimension
float scale = 0.10f; // The scale of the noise. The greater the scale, the denser the noise gets
float[,] noise = Noise.Calc2D(width, height, scale); // Returns an array containing 2D Simplex noise
```

#### Noise.Calc3D

Creates 3D Simplex noise.

```csharp
int width = 10, height = 15, length = 20; // The number of points to generate in the 1st, 2nd and 3rd dimension
float scale = 0.10f; // The scale of the noise. The greater the scale, the denser the noise gets
float[,,] noise = Noise.Calc3D(width, height, length, scale); // Returns an array containing 3D Simplex noise
```

#### Noise.CalcPixel1D

Gets the value of an index of 1D simplex noise.

```csharp
int x = 10; // Index
float scale = 0.10f; // The scale of the noise. The greater the scale, the denser the noise gets
float pixel = Noise.CalcPixel1D(x, scale); // Returns the value of an index of 1D simplex noise
```

#### Noise.CalcPixel2D

Gets the value of an index of 2D simplex noise.

```csharp
int x = 10, y = 15; // Indexes for the 1st and 2nd dimension
float scale = 0.10f; // The scale of the noise. The greater the scale, the denser the noise gets
float pixel = Noise.CalcPixel2D(x, y, scale); // Returns the value of an index of 2D simplex noise
```

#### Noise.CalcPixel3D

Gets the value of an index of 3D simplex noise.

```csharp
int x = 10, y = 15, z = 20; // Indexes for the 1st, 2nd and 3rd dimension
float scale = 0.10f; // The scale of the noise. The greater the scale, the denser the noise gets
float pixel = Noise.CalcPixel3D(x, y, z, scale);// Returns the value of an index of 3D simplex noise
```