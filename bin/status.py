#!/c/Python/python
import os
import sys
import getopt

def main(argv):
    cur = os.getcwd()
    dirs = os.listdir(cur)

    try:
        opts, args = getopt.getopt(argv, "huvc:",["branch="])
    except getopt.GetoptError:
      print('Invalid arguments.')

    print(opts)
    for opt, arg in opts:
      if opt == '-h':
          print('help')
      elif opt == '-u':
          print('update')
      elif opt == '-v':
          print('verbose')
      elif opt in ('-c', '--branch'):
         branch = arg
         print(f"checkout {branch}")

    for d in dirs:
        if os.path.isdir(d + "\\.git"):
            print(d)