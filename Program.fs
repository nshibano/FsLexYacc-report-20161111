open System
open Microsoft.FSharp.Text.Lexing

[<EntryPoint>]
let main argv = 
    let input_string = "ABC"

    let test lexbuf =
        let start_pos, end_pos = Parser.start Lexer.token lexbuf 
        let start_ofs = start_pos.AbsoluteOffset
        let end_ofs = end_pos.AbsoluteOffset
        Console.WriteLine(Printf.sprintf "Range is %d to %d." start_ofs end_ofs)
        Console.WriteLine(Printf.sprintf "Substring is \"%s\"" (input_string.Substring(start_ofs, end_ofs - start_ofs)))

    
    let lexbuf = LexBuffer<char>.FromString(input_string)
    test lexbuf

    Console.WriteLine("Try again with filename set to lexbuf.")

    let lexbuf = LexBuffer<char>.FromString(input_string)
    lexbuf.EndPos <- { lexbuf.EndPos with pos_fname = "filename" }

    test lexbuf

    Console.ReadKey() |> ignore
    0