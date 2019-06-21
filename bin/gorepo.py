#!/c/Python/python
import os
import sys

repos_dir = "w:\\repos"
cur = os.getcwd()

os.chdir(repos_dir)
repos = os.listdir(repos_dir)

n = 0
for r in repos:
    if os.path.isdir(r + "\\.git"):
        print(f"[{n}] {r}")
        n += 1

selection = int(input("Go to repo: "))
print(repos[selection])