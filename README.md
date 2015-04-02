# Simplex Noise

Simplex Noise implementation originally based on one by Heikki Törmälä (2012). It offers Simplex Noise in 1D, 2D, and 3D forms, returning values in the range of 0 to 255.

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