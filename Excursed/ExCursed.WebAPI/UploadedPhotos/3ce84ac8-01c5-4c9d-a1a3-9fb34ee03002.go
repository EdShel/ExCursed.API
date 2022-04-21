package filestrings

import (
	"bufio"
	"errors"
	"fmt"
	"os"
	"strconv"
	"strings"
)

const MOVIE_FILE_FORMAT = "%20v;\t%4d;\t%20v;\t%12d;\n"

type Movie struct{
	Title string
	Director string
	Year uint
	Cost uint
}

func WriteMoviesToFile(path string, movies []Movie) (error){
	file, err := os.Create(path)
	if err!=nil{
		return errors.New("can't write a file")
	}
	defer file.Close()

	for _, m := range movies{
		_, err = fmt.Fprintf(file, MOVIE_FILE_FORMAT, m.Title, m.Year, m.Director, m.Cost)
		if err!=nil{
			return errors.New("can't add movie to file")
		}
	}

	return nil
}

func AddMoviesToFile(path string, movies []Movie)(error){
	result := []Movie{}
	result = append(result, movies...)

	movies, err := ReadMoviesFromFile(path)
	if err!=nil{
		return err
	}
	result = append(result, movies...)

	err = WriteMoviesToFile(path, result)
	if err!=nil{
		return err
	}

	return nil
}

func ReadMoviesFromFile(path string)([]Movie, error){
	file, err := os.Open(path)
	if err!=nil{
		return nil, errors.New("can't write a file")
	}
	defer file.Close()

	movies := []Movie{}

	var (
		values []string
	)
	
	scanner := bufio.NewScanner(file)
	
	for scanner.Scan(){
		values = strings.Split(scanner.Text(), ";")
		if err:=scanner.Err(); err!=nil{
			return movies, err
		}

		title := strings.Trim(values[0], "\t ")
		director:= strings.Trim(values[2], "\t ")
		year, _ := strconv.Atoi(strings.Trim(values[1], "\t "))
		cost, _ := strconv.Atoi(strings.Trim(values[3], "\t "))

		movies = append(movies,
			Movie{
				Title: title, 
				Director: director, 
				Year: uint(year), 
				Cost: uint(cost), 
			},
		)

	}
	return movies, nil
}

func DeleteMoviesWithHigherCost(path string, cost uint)(error){
	movies, err := ReadMoviesFromFile(path)
	if err!=nil{
		return err
	}
	
	result := []Movie{}

	for _, movie := range movies{
		if movie.Cost < cost{
			result = append(result, movie)
		}
	}

	err = WriteMoviesToFile(path, result)
	if err !=nil{
		return err
	}

	return nil
}

func PrintMovies(movies []Movie){
	for i, movie := range movies{
		fmt.Printf("%d.\tTitle: %s\n", i+1,  movie.Title)
		fmt.Printf("\tYear: %d\n", movie.Year)
		fmt.Printf("\tDirector: %s\n", movie.Director)
		fmt.Printf("\tCost: %d\n\n", movie.Cost)
	}
}
