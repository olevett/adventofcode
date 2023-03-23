namespace AdventOfCode2018.Q1

module Part1 =
    open System

    let calculateFrequency (input: string) =
        input.Split(new List<string>() [",", "\r\n"], StringSplitOptions.RemoveEmptyEntries)

