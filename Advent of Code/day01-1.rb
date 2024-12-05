# From the input create 2 Hash object containing the values of the first column
# Hash has the row number as key, and value as integer
# example =>   column_left = { :0 => 4, :1 => 2 , ...}
#              column_right = {:0 => 3, :1 => 5 , ...}
example=
"3   4
4   3
2   5
1   3
3   9
3   3"


class InputToHash
    attr_accessor :column_left, :column_right
    def initialize(input)
        @column_left, @column_right = {}
        convert_to_hash(input)
    end

    def convert_to_hash(input)
        key = 0
        column_left=[]
        column_right=[]
        input.each_line do |line|
            values_array  = line.scan(/\w+/)
            column_left << [ key,  values_array[0].to_i]
            column_right << [ key,  values_array[1].to_i]
            key += 1
        end
        @column_left = column_left.to_h
        @column_right =  column_right.to_h
    end
end

class LocationsId < InputToHash
    attr_reader :total_distance

    def initialize(input)
        @total_distance = 0
        lists = InputToHash.new(input)
        distance_between_lists(lists)
    end

    def distance_between_lists(lists)
        
        # iteration until the lists if empty (left or right)
        while (lists.column_left.size > 0 ) do
            # search for smallest location_id in each column
            location_left = smallest_location_id(lists.column_left)
            location_right = smallest_location_id(lists.column_right)

            # remove the smallest location from each hash list
            lists.column_left.delete(location_left[0])
            lists.column_right.delete(location_right[0])

            # Add the absolute value for total_distance
            @total_distance += (location_left[1] - location_right[1]).abs()
        end
    end

    def smallest_location_id(list)
         list.sort_by { |key, value| value }.first
    end
end

# check if the example is correct.
puts LocationsId.new(example).total_distance

# execute on the puzzle input
# test the example against the puzzle
if (LocationsId.new(example).total_distance == 11)
    puzzle_input = File.read("day01-1-input.txt")
    puts LocationsId.new(puzzle_input).total_distance
end
