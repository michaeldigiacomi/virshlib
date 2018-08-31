# Virsh Library API ##In Development##

### This is being Actively Developed and should be treated as Such. This is not Production Ready Yet.

This Project is wrapping the virsh command in an useful Web API Written in .Net Core. This project can be used to build Custom Interfaces or Utilized with [VirtUI](https://github.com/mdigiacomi/VirtUI). Currently this is designed to work with KVM QEMU instances on the Linux Platform. It has been Tested with Ubuntu 18.04.



## Prerequisites:

* [.Net Core 2.1 Runtime](https://www.microsoft.com/net/download/linux-package-manager/rhel/runtime-2.1.3)
* libvirt [CentOS/Fedora/RHEL](https://www.cyberciti.biz/faq/how-to-install-kvm-on-centos-7-rhel-7-headless-server/)  [Debian/*buntu](https://www.cyberciti.biz/faq/installing-kvm-on-ubuntu-16-04-lts-server/)
* Has to be Running on VM Host For Now....

### 

## How To Run

1. Clone Repo
2. cd virshlib
3. dotnet run --project virshlib.api/virshlib.api.csproj



