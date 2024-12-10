# Ruby 3.3.6
#
input = <<~EXAMPLE
190: 10 19
3267: 81 40 27
83: 17 5
156: 15 6
7290: 6 8 6 15
161011: 16 10 13
192: 17 8 14
21037: 9 7 18 13
292: 11 6 16 20
EXAMPLE

class DataManipulation
  attr_reader :calibration_equations, :total_calibration_result


  def initialize(input, extended_operator)

    @calibration_equations = []
    @total_calibration_result = 0
    data_manipulation(input)
    main(extended_operator)
    print 'total_calibration_result: ',@total_calibration_result
    puts
  end

  def data_manipulation(input)
    # 190: 10 19 -> {test_value: 190, numbers: [10, 19], combination => numbers.length()}
    single_equation = {}
    input.each_line do |line|
      equation = line.scan(/\w+/).map(&:to_i)
      @calibration_equations << {
        test_value: equation.first(),
        numbers: equation.drop(1),
        combination: equation.drop(1).length()-1
      }
    end
  end

  def main(extended_operator)
    @calibration_equations.each do |equation|
      # print equation
      # puts
      equation_solving(equation,extended_operator)
      
    end
  end

  # PART I
  def equation_solving(equation,extended_operator)
    test_value = equation[:test_value]
    numbers = equation[:numbers]
    combination = equation[:combination]
    equation_solved = check_equation?(test_value,numbers,combination,false)
    if !equation_solved & extended_operator
      # Puts "check with expended operator"
      # Part II
      check_equation?(test_value,numbers,combination,extended_operator)
    end
end

  def generate_combination(combination,extended_operator)
    operators = ['*','+']
    return operators.repeated_permutation(combination).to_a if !extended_operator
   # Part II
   operators_with_extended_oprators = ['*','+','||']
    return operators_with_extended_oprators.repeated_permutation(combination).to_a if extended_operator
  end

  def check_equation?(test_value,numbers,combination,extended_operator)
    operators_combination = generate_combination(combination,extended_operator)
    operators_combination.each do |combination|
    if evaluate_equation(numbers,combination,extended_operator) == test_value then
      #print 'equation sovlved, value: ', test_value
      #puts
      @total_calibration_result += test_value
      return true
      break
    end
    end
    return false
  end

def evaluate_equation(numbers,combination,extended_operator)
  value = numbers[0]
  for index in  1..numbers.length()-1 do 
     value = (value  + numbers[index]) if (combination[index - 1] == '+') 
     value = (value  * numbers[index]) if (combination[index - 1] == '*') 
     value = (value.to_s + numbers[index].to_s).to_i if (combination[index - 1] == '||') if extended_operator
  end
  return value
end


end

# Part I
# or set part_II = true
puts "example"
extended_operator = true
DataManipulation.new(input, extended_operator)
# check for the puzzle
puts "puzzle"
puzzle_input = File.read("day03_input.txt")
DataManipulation.new(puzzle_input, extended_operator)
