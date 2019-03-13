# Simplex Noise

Simplex Noise implementation offering 1D, 2D, and 3D forms w/ values in the range of 0 to 255. Based on work by Heikki Törmälä (2012) and Stefan Gustavson (2006).

### Why use simplex noise?

Classic noise has problems with non-uniformity throughout its domain of definition, particularly for 2D planar slices of 3D and 4D noise, it has visible axis-aligned artefacts, it is expensive to compute for 4D and up, and its derivative in 3D and 4D is a very complicated high order polynomial.

Simplex noise is several times faster to compute, particularly for 4D and up, it does not have nearly as many visual problems with non-uniformity and axis-aligned artefacts, and it has a simple polynomial derivative everywhere, even for higher dimensions.

Simplex noise looks better, but different, and is thus visually incompatible with classic Perlin noise. The difference in feature size and range of values can easily be compensated for by a few simple scaling multiplications, but the different visual character might change the visual result of shaders that depend heavily on one or two components of noise. (Fractal sums of several noise components should still look about the same, though.)

Example of implementation:

    Simplex.Noise.Seed = 209323094; // Optional
    int length = 10, width = 15;
    float scale = 0.10f;
    float[,] noiseValues = Simplex.Noise.Calc2D(length, width, scale);


API:
- Simplex.Noise.Seed - Arbitrary integer seed used to generate lookup table used internally.
- float[] Simplex.Noise.Calc1D - returns an array containing 1D Simplex noise
- float[,] Simplex.Noise.Calc2D - returns an array containing 2D Simplex noise
- float[,,] Simplex.Noise.Calc3D - returns an array containing 3D Simplex noise
- float Simplex.Noise.CalcPixel1D - returns the value of an index of 1D simplex noise
- float Simplex.Noise.CalcPixel2D - returns the value of an index of 2D simplex noise
- float Simplex.Noise.CalcPixel3D - returns the value of an index of 3D simplex noise