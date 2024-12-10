# Ruby 3.3.6
#
input = <<~EXAMPLE
MMMSXXMASM
MSAMXMSMSA
AMXSXMAAMM
MSAMASMSMX
XMASAMXAMM
XXAMMXXAMA
SMSMSASXSS
SAXAMASAAA
MAMMMXMMMM
MXMXAXMASX
EXAMPLE

class ReportsToProgression
  attr_reader :word_count, :word_search_table 

  def initialize(input)
    @word_count = 0
    @word_search_table = []
    data_manipulation(input)
    main()
  end

  def data_manipulation(input)
    input.each_line do |line|
      
    end
  end

  def main()
    
  end
end