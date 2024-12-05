example="3   4
4   3
2   5
1   3
3   9
3   3
"

# From the input create 2 Hash object containing the values of the first column
# Hash has the row number as key, and value as integer
# example =>   column_left = { :0 => 4, :1 => 2 , ...}
#              column_right = {:0 => 3, :1 => 5 , ...}


class InputToHash
    attr_reader :column_left, :column_right
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
            column_left <<[ key,  values_array[0].to_i]
            column_right <<[ key,  values_array[1].to_i]
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
         list_left = lists.column_left
         list_right =lists.column_right

         # iteration until the lists if empty (left or right)
        while (list_left.size > 0 ) do

         # search for smallest location_id in each column
        location_left = smallest_location_id(list_left)
        location_right = smallest_location_id(list_right)

        # remove the smallet location from each hash list
        list_left.delete(location_left[0])
        list_right.delete(location_right[0])

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

if (LocationsId.new(example).total_distance == 11)
    puzzle_input = File.read("day01-1-input.txt")
    puts LocationsId.new(puzzle_input).total_distance
end
