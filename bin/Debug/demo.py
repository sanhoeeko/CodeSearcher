import os
import re

exclude_dir = ['__pycache__']
exclude_postfix = ['pyc', 'npz']


def get_postfix(s):
    arr = s.split('.')
    return arr[-1]


def get_dirname(s):
    arr = s.split('\\')
    return arr[-1]


def test(*args):
    print("hello! args =", *args)


def getAllSub(path, dirlist=[], filelist=[]):
    flist = os.listdir(path)
    for filename in flist:
        subpath = os.path.join(path, filename)
        if os.path.isdir(subpath):
            if get_dirname(subpath) not in exclude_dir:
                dirlist.append(subpath)  # 如果是文件夹，添加到文件夹列表中
                getAllSub(subpath, dirlist, filelist)  # 向子文件内递归
        if os.path.isfile(subpath):
            if get_postfix(subpath) not in exclude_postfix:
                filelist.append(subpath)  # 如果是文件，添加到文件列表中
    return filelist


def find_in_files(fs, keyword):
    for f in fs:
        try:
            with open(f, 'r', encoding='utf-8') as r:
                data = r.read()
        except:
            try:
                with open(f, 'r', encoding='ANSI') as r:
                    data = r.read()
            except:
                pass
        if keyword in data:
            yield f


def cdpath(path: str):
    try:
        path = re.sub("/", '\\\\', path)  # 正则表达式中用四个反斜杠匹配一个反斜杠
        os.chdir(path)
    except:
        print("You haven't set working path!")
    return path


def search(path, name):
    path = cdpath(path)
    files = getAllSub(path)
    for abs_f in find_in_files(files, name):
        f = abs_f[len(path) + 1:]
        print(f)
