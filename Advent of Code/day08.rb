# Ruby 3.3.6
#

input = <<~EXAMPLE
............
........0...
.....0......
.......0....
....0.......
......A.....
............
............
........A...
.........A..
............
............
EXAMPLE

class ReportsToProgression
  attr_reader :antenna_map,:antinode_count 

  def initialize(input)
    @antenna_map = []
    @antinode_count  = 0
    data_manipulation(input)
    main()
  end

  def data_manipulation(input)
    
  end

  def main()
    
  end
end