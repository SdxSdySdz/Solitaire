﻿namespace Solitaire.Model
{
    public interface ICopyable<out T>
    {
        T Copy();
    }
}