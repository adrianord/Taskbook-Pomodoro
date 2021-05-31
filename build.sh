#! /usr/bin/env bash
OUTPUT_DIR=./out
rm ${OUTPUT_DIR} -rf
dotnet publish -r linux-x64 -p:PublishSingleFile=true -o ${OUTPUT_DIR} -c Release src/TaskBookPomo.Cli

