def Average(array)
    i = 0
    sum = 0
    length = array.length
    while i<length do
        sum += array[i]
        i += 1
    end
    ave = sum/length
    return ave
end

def print(ave)
    puts ("Average is "),(ave)
    if ave < 10
        puts "Single Digits"
    else
        puts "Double Digits"
    end
end

def main()
    result = Average([1,2,3,4,7,12,1])
    print(result)
end
main()